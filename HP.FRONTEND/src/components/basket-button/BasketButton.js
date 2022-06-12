import React, { useContext } from 'react';
import { Badge, Button, Card, Col, Dropdown, DropdownButton, Image, Row } from 'react-bootstrap';
import { AppContext } from '../../contextapi/AppContext';
import './BasketButton.css'
import BasketProduct from './BasketProduct';

const BasketButton = () => {
    const { basketProducts } = useContext(AppContext);

    return (
        <Row>
            <div className='d-flex justify-content-end' style={{ width: "100%" }}>
                <Dropdown>
                    <span className='hp__basketBadge' >{basketProducts && basketProducts.length}</span> 
                    <DropdownButton align="end" title="Sepetim" className='hp__basketButton'>
                        {
                            basketProducts && basketProducts.length > 0 && basketProducts.map((product, key) => {
                                return (
                                    <React.Fragment key={key}>
                                        <BasketProduct product={product} />
                                        <Dropdown.Divider />
                                    </React.Fragment>
                                )
                            })
                        }
                    </DropdownButton>
                </Dropdown>

            </div>
        </Row>
    );
}

export default BasketButton;