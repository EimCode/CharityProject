import React, { Component, Fragment } from 'react';
import axios from 'axios';
import {
    Card, Button, CardImg, CardTitle, CardText, CardColumns,
    CardSubtitle, CardBody
  } from 'reactstrap';
import { render } from 'react-dom';
import AdvertsList from './AdvertsList';
import { withRouter } from 'react-router-dom';
import {connect} from 'react-redux';

class Adverts extends Component {


  
    handleDelete = id => {
      var config = {
        headers: {'Authorization': "bearer " + this.props.user.token}
    };

        axios.delete(`https://localhost:44342/api/Adverts/${id}`, config)
        .then(res => {
            console.log(res);
            console.log(res.data);
        });
    }

    render() {
        return(
          <div>
            <AdvertsList onDelete={(id) => this.handleDelete(id)} />
            <Button onClick={() => this.props.history.push("/advertCreation")}>Create</Button>
          </div>
        )
    }
}
const mapStateToProps = state => {
  return {
      user: state.userReducer.user
  }
}

export default withRouter(connect(mapStateToProps) (Adverts));