import { SET_SNACKBAR } from "../constants/action-types.js";

export function setSnackbar(open, variant, message){
    return{
        type: SET_SNACKBAR,
        payload: {
            open,
            variant,
            message
        }
    }
} 