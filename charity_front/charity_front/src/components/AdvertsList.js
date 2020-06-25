import React from 'react';
import axios from 'axios';
import { withRouter } from 'react-router-dom';
import {
    Card, Button, CardImg, CardTitle, CardText, CardColumns,
    CardSubtitle, CardBody
  } from 'reactstrap';
import {connect} from 'react-redux';
import {setAdverts, addAdvert} from "../actions/AdActions.js"

class AdvertsList extends React.Component{
    state = {
        ads: []
    }

    componentDidMount() {
        axios.get('https://localhost:44342/api/Adverts')
        .then(res => {
            console.log(res.data);
            this.setState({ads: res.data});
            this.props.setAdverts(res.data);
        });
    }

    render() {
        console.log(this.props.user)
        return (
            <>
            {this.props.user.token ? 
            this.state.ads.map(ad => 
            <Card key={ad.id} body inverse color="primary">
                <CardTitle>
                    {ad.restaurant.name}
                </CardTitle>
                <CardText>{ad.description}</CardText>
              <Button color="secondary">Skaityti detaliau</Button>
              <Button color="secondary" onClick={() => this.props.onDelete(ad.id)}>X</Button>
            </Card>
            )
            : null}
        </>
        )
    }
}

const mapStateToProps = state => {
    return {
        user: state.userReducer.user
    }
}

const mapDispatchToProps = dispatch => {
    return {
        setAdverts: (adverts) => dispatch(setAdverts(adverts))
    }
}

export default withRouter(connect(mapStateToProps, mapDispatchToProps) (AdvertsList));