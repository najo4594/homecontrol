import React, {Component} from 'react';
import {Card, Col, Row} from 'react-bootstrap'
import {withRouter} from "react-router-dom";

class Room extends Component {

    constructor(props) {
        super(props);

        this.state = {
            loading: true,
            error: false,
            devices: null
        };
    }

    componentDidMount() {
        const roomId = this.getRoomId(this.props);
        this.getDevices(roomId);
    }

    shouldComponentUpdate(nextProps, nextState, nextContext) {
        const oldRoomId = this.getRoomId(this.props);
        const newRoomId = this.getRoomId(nextProps);
        const oldLoading = this.state.loading;
        const newLoading = nextState.loading;

        if (newRoomId !== oldRoomId) {
            this.getDevices(newRoomId);
            return true;
        }

        return oldLoading !== newLoading;
    }

    async getDevices(roomId) {
        this.setState({loading: true});
        const devicesResponse = await fetch(`api/rooms/devices?roomId=${roomId}`);
        if (devicesResponse.ok) {
            const devicesData = await devicesResponse.json();
            this.setState({devices: devicesData, loading: false, error: false});
        } else {
            this.setState({devices: null, loading: false, error: true})
        }
    }

    getRoomId(props) {
        let roomId = null;
        if (Number.isInteger(+props.match.params.roomId)) {
            roomId = parseInt(props.match.params.roomId);
        }
        return roomId
    }


    render() {
        if (this.state.loading) {
            return <p>Loading...</p>
        } else if (this.state.error) {
            return <p>Error happened :(</p>
        } else {
            return <Row>
                {this.state.devices.map(device =>
                    <Col xs={3} className="my-3">
                        <Card>
                            <Card.Header>{device.name}</Card.Header>
                            <Card.Body>
                                Some information about the device
                            </Card.Body>
                        </Card>
                    </Col>
                )}
            </Row>
        }
    }
}

export default withRouter(Room);
