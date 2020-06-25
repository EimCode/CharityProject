import axios from "axios";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import { useHistory } from "react-router-dom";
import React, {Component} from 'react';
import { setSnackbar } from "../actions/SnackbarActions";

const SET_USER = "SET_USER";
const LOGOUT = "LOGOUT";
const REGISTER = "REGISTER";

const serverUrl = "https://localhost:44342/api";

function setUser(user){
    return{
        type: SET_USER,
        payload: user
    }
}

export function logout(){
    return{
        type: LOGOUT
    }
}

export function login(user) {

    return function(dispatch){
            console.log(user.email + " " + user.password)
            return axios.post(`${serverUrl}/Users/authenticate`, {
                email: user.email,
                password: user.password,
            }).then(res => {
                dispatch(setUser(res.data));
                dispatch(setSnackbar(true, "success", "Welcome !"));


            }).catch(error => {

                if(error.response.status == 400){
                    dispatch(setSnackbar(true, "error", "Incorrect credentials !"));
                }
            });
    }
};