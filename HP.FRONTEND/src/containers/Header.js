import { faSearch } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import React, { useState } from 'react';
import { Col, Container, Form, FormControl, Image, InputGroup, Row } from 'react-bootstrap';
import hpLogo from '../assets/logo.png'
import BasketButton from '../components/basket-button/BasketButton';
import { clearURLSearchParams, setURLSearchParam } from '../helpers/CommonHelper';
import './Header.css'

const Header = () => {
    const [searchText, setSearchText] = useState(null)

    const handleKeyDown = (event) => {
        if (event.key === 'Enter') {
            if(searchText.length > 1){
                clearURLSearchParams()
                setURLSearchParam("searchText", searchText);
            }
        }
    }

    return (
        <div className='hp__header pb-3'>
            <Container>
                <Row>
                    <Col md={4} className="d-flex justify-content-start">
                        <Image className='align-self-center' src={hpLogo} height={30} />
                    </Col>
                    <Col md={4} className="d-flex h-100 justify-content-center">
                        <InputGroup className='search-bar'>
                            <FormControl
                                type="text"
                                placeholder="Search..."
                                onChange={(event) => setSearchText(event.currentTarget.value)}
                                onKeyDown={handleKeyDown}
                            />
                            <div className="align-self-center search-icon">
                                <FontAwesomeIcon icon={faSearch} />
                            </div>
                        </InputGroup>
                    </Col>
                    <Col md={4} className="d-flex justify-content-end">
                        <BasketButton />
                    </Col>
                </Row>
            </Container>
        </div>
    );
}

export default Header;