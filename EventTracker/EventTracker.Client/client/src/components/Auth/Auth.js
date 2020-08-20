import React, { Component } from 'react';
import { Route, Switch, Redirect } from 'react-router-dom'; 
import Login from './Login';
import Register from './Register';

class Auth extends Component {
    render() {
        return (
            <Switch>
                <Route exact path="/auth/login" component={Login} />
                <Route exact path="/auth/register" component={Register} />
                <Redirect from="/auth/*" to="/auth/login" />
            </Switch>
        )
    }
}

export default Auth;