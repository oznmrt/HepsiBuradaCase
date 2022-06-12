import React, { useContext, useState } from 'react';
import { Button, Col, Image, Modal, Row } from 'react-bootstrap';
import { AppContext } from '../../contextapi/AppContext';
import { LS_BASKET_KEY } from '../../helpers/Constants';
import './BasketProduct.css';

const BasketProduct = (props) => {
    const { basketProducts, setBasketProducts } = useContext(AppContext);

    const [modalVisible, setModalVisible] = useState(false);

    const onClickRemoveProduct = () => {
        var cpBasketProducts = [...basketProducts];
        var filteredData = cpBasketProducts.filter(item => item.id !== props.product.id)
        setBasketProducts(filteredData);
        localStorage.setItem(LS_BASKET_KEY, JSON.stringify(filteredData))
        setModalVisible(false);
    }

    return (
        <React.Fragment>
            <Row>
                <Col md={2}>
                    <Image style={{ width: "100%" }} src={props.product.imagePath} />
                </Col>
                <Col md={6}>
                    <p>{props.product.name}</p>
                </Col>
                <Col md={12} className='d-flex justify-content-end'>
                    <Button variant='outline-danger' onClick={() => setModalVisible(true)}>Kaldır</Button>
                </Col>
            </Row>
            <Modal show={modalVisible} onHide={() => setModalVisible(!modalVisible)}>
                <Modal.Header closeButton>
                    <Modal.Title>Ürünü silmek istediğinize emin misiniz ?</Modal.Title>
                </Modal.Header>
                <Modal.Body>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentiall...</Modal.Body>
                <Modal.Footer>
                    <Button variant="danger" onClick={() => setModalVisible(!modalVisible)}>
                        Hayır
                    </Button>
                    <Button variant="success" onClick={onClickRemoveProduct}>
                        Evet
                    </Button>
                </Modal.Footer>
            </Modal>
        </React.Fragment>
    );
}

export default BasketProduct;