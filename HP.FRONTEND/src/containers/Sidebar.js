import React, { useContext } from 'react';
import { Col, Row } from "react-bootstrap";
import { AppContext } from '../contextapi/AppContext';
import { checkURLSearchParamsForSortOptions, setURLSearchParamWithValueValidation, groupByArr } from '../helpers/CommonHelper';
import { SORT_TYPES } from '../helpers/Constants';
import './Sidebar.css';

const Sidebar = (props) => {
    const { pageData } = useContext(AppContext);

    const onClickColor = (colorId) => {
        setURLSearchParamWithValueValidation("colorId", colorId);
    }

    const onClickBrand = (brandId) => {
        setURLSearchParamWithValueValidation("brandId", brandId);
    }

    const onClickSort = (sortType) => {
        checkURLSearchParamsForSortOptions(sortType)
        setURLSearchParamWithValueValidation(sortType, true);
    }

    const groupedColorData = pageData && pageData.colors && pageData.colors.length > 0 && groupByArr(pageData.colors, "id");
    const groupedBrandData = pageData && pageData.brands && pageData.brands.length > 0 && groupByArr(pageData.brands, "id");
    return (
        <Row>
            <Col md={12}>
                <h6 className='hp__sideBarHeaderLabel'>Renk</h6>
                {
                    groupedColorData && Object.keys(groupedColorData).map(item => {
                        console.log(groupedColorData[item])
                        return (
                            <p className='hp__sideBarLabel' onClick={() => onClickColor(item)}>{groupedColorData[item][0]["name"]} ({groupedColorData[item].length})</p>
                        )
                    })
                }
            </Col>

            <Col md={12}>
                <h6 className='hp__sideBarHeaderLabel'>Sıralama</h6>
                <p className='hp__sideBarLabel' onClick={() => onClickSort(SORT_TYPES.SortByPriceASC)}>En Düşük Fiyat</p>
                <p className='hp__sideBarLabel' onClick={() => onClickSort(SORT_TYPES.SortByPriceDESC)}>En Yüksek Fiyat</p>
                <p className='hp__sideBarLabel' onClick={() => onClickSort(SORT_TYPES.SortByDateASC)}>{"En Yeniler (A>Z)"}</p>
                <p className='hp__sideBarLabel' onClick={() => onClickSort(SORT_TYPES.SortByDateDESC)}>{"En Yeniler (Z<A)"}</p>
            </Col>

            <Col md={12}>
                <h6 className='hp__sideBarHeaderLabel'>Marka</h6>
                {
                    groupedBrandData && Object.keys(groupedBrandData).map(item => {
                        console.log(groupedBrandData[item])
                        return (
                            <p className='hp__sideBarLabel' onClick={() => onClickBrand(item)}>{groupedBrandData[item][0]["name"]} ({groupedBrandData[item].length})</p>
                        )
                    })
                }
            </Col>
        </Row>
    );
}

export default Sidebar;