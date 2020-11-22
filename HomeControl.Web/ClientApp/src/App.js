import React, {Component} from 'react';
import {
    BrowserRouter as Router,
    Switch,
    Route,
} from "react-router-dom";
import {Home} from './components/Home';

import './custom.css'
import {Lights} from './components/Lights';
import Room from './components/Room.js';
import {Layout} from "./components/Layout";

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Router>
                    <Switch>
                        <Route exact path='/'>
                            <Home/>
                        </Route>
                        <Route path='/lights'>
                            <Lights/>
                        </Route>
                        <Route path='/rooms/:roomId'>
                            <Room/>
                        </Route>
                    </Switch>
                </Router>
            </Layout>
        );
    }
}
