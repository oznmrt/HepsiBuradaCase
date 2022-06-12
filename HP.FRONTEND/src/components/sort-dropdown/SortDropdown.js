import React, { useContext } from 'react';
import { Dropdown, DropdownButton, FormControl } from "react-bootstrap";
import { AppContext } from '../../contextapi/AppContext';
import { checkURLSearchParamsForSortOptions, setURLSearchParamWithValueValidation } from '../../helpers/CommonHelper';
import { SORT_TYPES } from '../../helpers/Constants';
import './SortDropdown.css'

const SortDropdown = () => {
    const { selectedSortType } = useContext(AppContext);

    const onSelectSort = (sortType) => {
        checkURLSearchParamsForSortOptions(sortType)
        setURLSearchParamWithValueValidation(sortType, true);
    }

    return (
        <div className='hp__sortButton'>
            <select defaultValue="Sıralama"
                onChange={(e) => onSelectSort(e.target.value)}>
                <option selected disabled style={{"display": "none"}}>Sıralama</option>
                <option value={SORT_TYPES.SortByPriceASC} selected={selectedSortType === SORT_TYPES.SortByPriceASC}>En Düşük Fiyat</option>
                <option value={SORT_TYPES.SortByPriceDESC} selected={selectedSortType === SORT_TYPES.SortByPriceDESC}>En Yüksek Fiyat</option>
                <option value={SORT_TYPES.SortByDateASC} selected={selectedSortType === SORT_TYPES.SortByDateASC}>{"En Yeniler (A>Z)"}</option>
                <option value={SORT_TYPES.SortByDateDESC} selected={selectedSortType === SORT_TYPES.SortByDateDESC}>{"En Yeniler (Z>A)"}</option>
            </select>
        </div>
    );
}

export default SortDropdown;