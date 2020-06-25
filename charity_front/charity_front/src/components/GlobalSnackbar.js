import React, { Component } from 'react';
import { connect } from "react-redux";

import SnackbarMessage from "../components/SnackbarMessage";
import { setSnackbar } from "../actions/SnackbarActions";

class GlobalSnackbar extends Component {

    render() { 
        return (
            <SnackbarMessage open={this.props.open} variant={this.props.variant} message={this.props.message} onClose={() => this.props.close()}></SnackbarMessage>
        );
    }
}

const mapStateToProps = state => {
    return {
        open: state.snackbarReducer.open,
        variant: state.snackbarReducer.variant,
        message: state.snackbarReducer.message
    }
}

const mapDispatchToProps = dispatch => {
    return {
        close: () => dispatch(setSnackbar(false, "success", "empty"))
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(GlobalSnackbar); 