import React from 'react';
import axios from 'axios';
import { withRouter } from 'react-router-dom';

class UserInput extends React.Component{
    state = {
        name: '',
        email: '',
        password: '',
        role: '',
    };

    handleEmailChange = event => {
        this.setState({ 
            email: event.target.value,
        });
    }

    handleNameChange = event => {
        this.setState({
            name: event.target.value
        });
    }

    handlePasswordChange = event => {
        this.setState({
            password: event.target.value
        });
    }

    handleRoleChange = event => {
        this.setState({
            role: event.target.value
        });
    }

    handleSubmit = event => {
        event.preventDefault();

        const user = {
            name: this.state.name,
            email: this.state.email,
            password: this.state.password,
            role: this.state.role,
        }

        axios.post('https://localhost:44342/api/Users', user)
        .then(res => {
            console.log(res);
            console.log(res.data);
        }).then(this.props.history.push("/sign-in"));
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <h3>Sign Up</h3>

                <div className="form-group">
                    <label>Name</label>
                    <input type="text" name="name" className="form-control" placeholder="First name" onChange={this.handleNameChange} />
                </div>

                <div className="form-group">
                    <label>Email address</label>
                    <input type="email" name="email" className="form-control"  placeholder="Enter email" onChange={this.handleEmailChange} />
                </div>

                <div className="form-group">
                    <label>Password</label>
                    <input type="password" name="password" className="form-control" placeholder="Enter password" onChange={this.handlePasswordChange} />
                </div>
                <div className="form-group">
                    <label>Name</label>
                    <input type="text" name="role" className="form-control" placeholder="Enter role" onChange={this.handleRoleChange} />
                </div>
                <button type="submit" >Add</button>
                <p className="forgot-password text-right">
                    Already registered <a href="/sign-in">sign in?</a>
                </p>
            </form>
        );
    }
}
export default withRouter(UserInput);