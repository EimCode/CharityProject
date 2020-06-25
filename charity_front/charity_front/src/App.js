import React from 'react';
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";

import Login from "./components/login.component";
import SignUp from "./components/signup.component";
import Adverts from "./components/Adverts";
import AdvertCreation from "./components/AdvertInput";
import GlobalSnackbar from './components/GlobalSnackbar';


function App(){
 return(
   <>
  <Router>
    <div className="App">
      <nav className="navbar navbar-expand-lg navbar-light fixed-top">
        <div className="container">
          <Link className="navbar-brand" to={"/sign-in"}>Charity-Project</Link>
            <ul className="navbar-nav ml-auto">
              <li className="nav-item">
                <Link className="nav-link" to={"/sign-in"}>Login</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to={"/sign-up"}>Sign up</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to={"/adverts"}>Adverts</Link>
              </li>
            </ul>
        </div>
      </nav>
      <div className="auth-wrapper">
        <div className="auth-inner">
          <Switch>
            <Route exact path='/' component={Login} />
            <Route path="/sign-in" component={Login} />
            <Route path="/sign-up" component={SignUp} />
            <Route path="/adverts" component={Adverts} />
            <Route path="/advertCreation" component={AdvertCreation} />
          </Switch>
        </div>
      </div>
    </div></Router>
    <GlobalSnackbar></GlobalSnackbar>
    </>
  );
}

export default App;
