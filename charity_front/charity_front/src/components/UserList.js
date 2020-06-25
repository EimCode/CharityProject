import React from 'react';
import axios from 'axios';

export default class UserList extends React.Component{
    state = {
        users: []
    }

    componentDidMount() {
        axios.get('https://localhost:44342/api/Users')
        .then(res => {
            console.log(res.data);
            this.setState({users: res.data});
        });
    }

    render() {
        return <ul>{this.state.users.map(user => <li key={user.id}>{user.email}</li>)}
        </ul>
    }
}