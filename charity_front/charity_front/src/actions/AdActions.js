import { SET_ADVERTS } from "../constants/action-types";
import { ADD_ADVERT } from "../constants/action-types";

export function setAdverts(adverts){
    return{
        type: SET_ADVERTS,
        payload: adverts
    }
} 

export function addAdvert(advert){
    return{
        type: ADD_ADVERT,
        payload: advert
    }
} 