import { SORT_TYPES } from "./Constants";

export const setURLSearchParamWithValueValidation = (key, value) => {
    const url = new URL(window.location.href);

    if (url.searchParams.has(key)){
        var searchValue = url.searchParams.get(key);
        if(searchValue === value)
            url.searchParams.delete(key)
        else 
            url.searchParams.set(key, value);
    }
    else {
        url.searchParams.set(key, value);
    }

    window.history.pushState({ path: url.href }, '', url.href);
    window.location.reload();
}

export const setURLSearchParam = (key, value) => {
    const url = new URL(window.location.href);

    if (url.searchParams.has(key)){
        url.searchParams.delete(key)
        window.history.pushState({ path: url.href }, '', url.href);
    }
    
    url.searchParams.set(key, value);

    window.history.pushState({ path: url.href }, '', url.href);
    window.location.reload();
}

export const checkURLSearchParamsForSortOptions = (sortType) => {
    const url = new URL(window.location.href);
    Object.keys(SORT_TYPES).forEach(key => {
        if(sortType !== SORT_TYPES[key])
            url.searchParams.delete(SORT_TYPES[key])
    })
    window.history.pushState({ path: url.href }, '', url.href);
}

export const getURLSearchParams = () => {
    const urlSearchParams = new URLSearchParams(window.location.search);
    const params = Object.fromEntries(urlSearchParams.entries());
    return params;
}

export const clearURLSearchParams = () => {
    var newURL = window.location.href.split("?")[0];
    window.history.pushState('object', document.title, newURL);
}

export const groupByArr = (items, key) => items.reduce(
    (result, item) => ({
        ...result,
        [item[key]]: [
            ...(result[item[key]] || []),
            item,
        ],
    }),
    {},
);

export const customIntParse = (x) => {
    const parsed = parseInt(x);
    if (isNaN(parsed)) { return 0; }
    return parsed;
  }