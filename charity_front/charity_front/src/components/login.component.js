import React, { Component, Fragment } from 'react';
import UserList from './UserList';
import UserDelete from './UserDelete';
import {connect} from 'react-redux';
import {login} from './loginAction';
import { withRouter } from 'react-router-dom';


class Login extends Component {

    state = {
        email: "",
        password: ""
    }

    componentDidUpdate(prevProps, prevState) {
        console.log("Updated")
        console.log(this.props.user)
        if(this.props.user.token){
          this.props.history.push("/adverts");
        }
      }

    handleSubmit = event => {
        event.preventDefault();

        const user = {
            email: this.state.email,
            password: this.state.password,
        }

        this.props.Login(user);
    }

    

    validateForm() {
        return this.state.email.length > 0 && this.state.password.length > 0;
      }

    render() {
        return (
            <React.Fragment>
            <form onSubmit={this.handleSubmit}>
                <h3>Sign In</h3>

                <div className="form-group">
                    <label>Email address</label>
                    <input type="email" className="form-control" placeholder="Enter email" onChange={e => this.setState({email: e.target.value})} />
                </div>

                <div className="form-group">

                    <label>Password</label>
                    <input type="password" className="form-control" placeholder="Enter password" onChange={ e => this.setState({password: e.target.value})} />
                </div>

                <div className="form-group">
                    <div className="custom-control custom-checkbox">
                        <input type="checkbox" className="custom-control-input" id="customCheck1" />
                        <label className="custom-control-label" htmlFor="customCheck1">Remember me</label>
                    </div>
                </div>

                <button disabled={!this.validateForm()} type="submit" className="btn btn-primary btn-block">
                    Submit
                </button>
                <p className="forgot-password text-right">

                    Forgot <a href="#">password?</a>
                </p>
            </form>
            <UserList />
            <UserDelete />
          </React.Fragment>
        );
    }
}

const mapStateToProps = state => {
    return {
        user: state.userReducer.user
    }
}

const mapDispatchToProps = dispatch => {
    return {
        Login: (user) => dispatch(login(user))
    }
}

export default connect(mapStateToProps, mapDispatchToProps) (Login);