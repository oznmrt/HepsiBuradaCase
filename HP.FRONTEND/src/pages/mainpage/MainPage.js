import React, { useContext, useEffect } from 'react';
import { Col, Dropdown, DropdownButton, Row } from "react-bootstrap";
import axios from 'axios';
import Product from '../../components/product/Product';
import Layout from '../../containers/Layout';
import Sidebar from '../../containers/Sidebar';
import './MainPage.css'
import { AppContext } from '../../contextapi/AppContext';
import { getURLSearchParams } from '../../helpers/CommonHelper';
import SortDropdown from '../../components/sort-dropdown/SortDropdown';
import { LS_BASKET_KEY, SORT_TYPES } from '../../helpers/Constants';
import CustomPagination from '../../components/custom-pagination/CustomPagination';

const MainPage = (props) => {
    const { pageData, setPageData, selectedSortType, setSelectedSortType, basketProducts, setBasketProducts, } = useContext(AppContext);
    useEffect(() => {
        checkSortTypesForFilters();
        checkLocalStorageForBasketProducts();
        getProducts();
    }, [])

    const checkSortTypesForFilters = () => {
        var params = getURLSearchParams();
        Object.keys(SORT_TYPES).forEach(key => {
            var value = params[SORT_TYPES[key]]
            if(value){
                setSelectedSortType(SORT_TYPES[key]);
                return;
            }
        })
    }

    const checkLocalStorageForBasketProducts = () => {
        var serializedBasketData = localStorage.getItem(LS_BASKET_KEY)
        if(serializedBasketData){
            var convertedData = JSON.parse(serializedBasketData);
            setBasketProducts(convertedData);
        }
    }

    const getProducts = () => {
        var params = getURLSearchParams()
        var request = {
            ...params
        }
        axios.post(`${window.app.config.API_BASE_URL}/Product/getproducts`, request)
            .then((response) => {
                setPageData(response.data)
            })
            .catch((err) => {
                console.log(err);
            })
    }

    const params = getURLSearchParams()

    return (
        <Layout {...props}>
            <Row>
                <Col md={6}>
                    <h4>iPhone iOS cep telefonu</h4>
                    {
                        params.searchText &&
                        <span>Aranan kelime: {params.searchText}</span>
                    }
                </Col>
                <Col md={6} className="d-flex justify-content-end">
                    <SortDropdown />
                </Col>
                <Col md={3}>
                    <Sidebar />
                </Col>
                <Col md={9}>
                    <Row>
                        {pageData && pageData.products && pageData.products.map(product => {
                            return (
                                <Col md={3}>
                                    <Product product={product} />
                                </Col>
                            )
                        })}
                    </Row>
                    <Row>
                        <Col md={12} className="d-flex justify-content-start">
                            <CustomPagination pageCount={pageData?.maxPageCount} />
                        </Col>
                    </Row>
                </Col>
             
            </Row>
        </Layout>
    );
}

export default MainPage;