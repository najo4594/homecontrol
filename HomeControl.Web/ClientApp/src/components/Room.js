import React, {Component} from 'react';
import {Card, Col, Row} from 'react-bootstrap'
import {withRouter} from "react-router-dom";

class Room extends Component {

    constructor(props) {
        super(props);

        let roomId = null;
        if (Number.isInteger(+this.props.match.params.roomId)) {
            roomId = parseInt(this.props.match.params.roomId);
        }

        this.state = {
            loading: true,
            roomId: roomId,
            devices: null
        };
    }

    componentDidMount() {
        this.getDevices();
    }

    render() {
        return (
            this.state.loading ? <p>Loading...</p> :
                <Row>
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
