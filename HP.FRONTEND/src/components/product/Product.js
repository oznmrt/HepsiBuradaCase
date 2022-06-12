import React, { useContext } from 'react';
import { Button, Col, Image, Row } from 'react-bootstrap';
import { AppContext } from '../../contextapi/AppContext';
import { LS_BASKET_KEY } from '../../helpers/Constants';
import './Product.css'

const Product = (props) => {
    const { basketProducts, setBasketProducts } = useContext(AppContext);

    const onClickAddProductBasket = () => {
        var cpBasketProducts = [...basketProducts];
        cpBasketProducts.push(props.product)
        setBasketProducts(cpBasketProducts);

        localStorage.setItem(LS_BASKET_KEY, JSON.stringify(cpBasketProducts))
    }

    const isProductInBasket = basketProducts && basketProducts.length > 0 ? basketProducts.filter(item => item.id === props.product.id).length > 0 : false;
    const calculatedProductPrice = props.product.discountRatio > 0 ? props.product.price - ((props.product.price * props.product.discountRatio) / 100) : props.product.price
    return (
        <div className='hp__product'>
            <div className='hp__produtImage'>
                <Image src={props.product.imagePath} />
            </div>
            <Col md={12} className='hp__productDetail'>
                <div className='hp__productLabel'>
                    <p>{props.product.name}</p>
                    <p><b>Marka: </b>{props.product.brand.name}</p>
                    <p><b>Renk: </b>{props.product.color.name}</p>
                    <h6>{calculatedProductPrice} TL</h6>
                    <p><span className='hp__discountLabel'>{props.product.price} TL </span> <span className='hp__discountRatioLabel'>{props.product.discountRatio}%</span></p>
                </div>
            </Col>
            <Col md={12} className='hp__productBasket'>
                <div className='hp__productLabel pb-1'>
                    <p className='pb-3'>{props.product.name}</p>
                    {isProductInBasket ?
                        <Button className='hp__productBasketButton' disabled>Bu ürünü sepete ekleyemezsiniz.</Button>
                        :
                        <Button className='hp__productBasketButton' onClick={onClickAddProductBasket}>Sepete Ekle</Button>
                    }
                </div>
            </Col>
        </div>
    );
}

export default Product;