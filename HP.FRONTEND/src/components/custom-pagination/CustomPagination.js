import React from 'react';
import { Pagination } from 'react-bootstrap';
import { customIntParse, getURLSearchParams, setURLSearchParam } from '../../helpers/CommonHelper';

const CustomPagination = (props) => {

    const urlParams = getURLSearchParams();
    const onClickPage = (page) => {
      setURLSearchParam("page", page);
    }

    const currentPage = customIntParse(urlParams.page) === 0 ? 1 : customIntParse(urlParams.page)

    let paginationItems = [];
    for (let number = 1; number <= props.pageCount; number++) {
        paginationItems.push(
          <Pagination.Item onClick={() => onClickPage(number)} key={number} active={number === currentPage}>
            {number}
          </Pagination.Item>,
        );
    }
    return (
        <Pagination>{paginationItems}</Pagination>
     );
}

export default CustomPagination;