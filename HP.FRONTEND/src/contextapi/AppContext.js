import React, { useState, createContext } from 'react';

export const AppContext = createContext();

export const AppContextProvider = (props) => {
    const [pageData, setPageData] = useState({});
    const [selectedSortType, setSelectedSortType] = useState(null);
    const [basketProducts, setBasketProducts] = useState([]);

    return (
        <AppContext.Provider value={{pageData, setPageData,
                                     selectedSortType, setSelectedSortType,
                                     basketProducts, setBasketProducts}}>
            {props.children}
        </AppContext.Provider>
    )
}
