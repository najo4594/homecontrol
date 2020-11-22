import React, {Component} from 'react';
import {Card, Col, Row} from 'react-bootstrap'
import {useParams, withRouter} from "react-router-dom";

class Room extends Component {

    constructor(props) {
        super(props);
         
        let roomId = null;
        if(Number.isInteger(+this.props.match.params.roomId)){
            roomId = parseInt(this.props.match.params.roomId);
        }        
        
        this.state = {
            isLoading: true,
            roomId: roomId,
            devices: null
        };
    }

    componentDidMount() {                   
        this.getDevices();
    }

    render() {
        return (
            <h1>{this.state.roomId}</h1>
        );
    }

    async getDevices() {
        const devicesResponse = await fetch(`api/rooms/devices?roomId=${this.state.roomId}`);
        const devicesData = await devicesResponse.json();
        this.setState({devices: devicesData});

        this.setState({loading: false});
    }
}

export default withRouter(Room);
