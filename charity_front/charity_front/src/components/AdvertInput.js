import React from 'react';
import axios from 'axios';
import { withRouter } from 'react-router-dom';
import {
    Card, Button, CardImg, CardTitle, CardText, CardColumns,
    CardSubtitle, CardBody
  } from 'reactstrap';

  import {connect} from 'react-redux';

  import {addAdvert} from "../actions/AdActions.js"

class AdvertInput extends React.Component{
    state = {
        date: '',
        description: '',
    };

    handleDescriptionChange = event => {
        this.setState({
            description: event.target.value
        });
    }

    handleDateChange = event => {
        this.setState({
            date: event.target.value
        });
    }

    handleSubmit = event => {
        event.preventDefault();

        const advert = {
            date: this.state.date,
            description: this.state.description,
        }

        var config = {
            headers: {'Authorization': "bearer " + this.props.user.token}
        };

        axios.post('https://localhost:44342/api/Adverts', advert, config )
        .then(res => {
            this.props.addAdvert(res.data);
            this.props.history.push("/adverts");
        }).catch( error => {
            console.log()
        })
    }

    handleCancel = event => {
        this.props.history.push("/adverts")
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit} onReset={this.handleCancel}>
                <h3>Advert creation</h3>
                <div className="form-group">
                    <label>Date</label>
                    <input type="date" name="description" className="form-control" placeholder="Adverts description" onChange={this.handleDateChange} />
                    <label>Description</label>
                    <input type="text" name="description" className="form-control" placeholder="Adverts description" onChange={this.handleDescriptionChange} />
                    
                </div>
                <Button type="submit">Add</Button>
                <Button type="reset">Cancel</Button>
            </form>
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
        addAdvert: (advert) => dispatch(addAdvert(advert))
    }
}

export default withRouter(connect(mapStateToProps, mapDispatchToProps) (AdvertInput));