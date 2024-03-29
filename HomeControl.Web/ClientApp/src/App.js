import React, {Component} from 'react';
import {
    BrowserRouter as Router,
    Switch,
    Route,
} from "react-router-dom";
import {Home} from './components/Home';

import './custom.css'
import Room from './components/Room.js';
import {Layout} from "./components/Layout";

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Router>
                <Layout>
                    <Switch>
                        <Route exact path='/'>
                            <Home/>
                        </Route>
                        <Route path='/rooms/:roomId'>
                            <Room/>
                        </Route>
                    </Switch>
                </Layout>
            </Router>
        );
    }
}
