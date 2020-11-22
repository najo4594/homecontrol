import React, {Component} from 'react';
import {Card, Col, Row} from 'react-bootstrap'
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faCheckCircle, faTimesCircle} from '@fortawesome/free-solid-svg-icons';

export class Lights extends Component {
    static displayName = Lights.name;

    constructor(props) {
        super(props);
        this.state = {lights: [], rooms: [], loading: true};
    }

    componentDidMount() {
        this.getLightsData();
    }

    render() {
        return (
            this.state.loading ? <p>Loading...</p> :
                <>
                    <Row>
                        {this.state.lights.map(light =>
                            <Col xs={3} className="my-3">
                                <Card>
                                    <Card.Header>{light.name}</Card.Header>
                                    <Card.Body>
                                        <Row>
                                            <Col xs={6}>
                                                <p>Zustand:</p>
                                            </Col>
                                            <Col xs={6} className={'text-right'}>
                                                <p>{light.state.on ?
                                                    <FontAwesomeIcon icon={faCheckCircle}
                                                                     className="primary active-device"/> :
                                                    <FontAwesomeIcon icon={faTimesCircle} className="inactive-device"/>}
                                                </p>
                                            </Col>
                                        </Row>
                                        <Row>
                                            <Col xs={6}>
                                                <p>Raum:</p>
                                            </Col>
                                            <Col xs={6} className={'text-right'}>
                                                <p>{this.getRoomName(light.roomId)}</p>
                                            </Col>
                                        </Row>
                                    </Card.Body>
                                </Card>
                            </Col>
                        )}
                    </Row>
                </>
        );
    }

    async getLightsData() {
        const lightsResponse = await fetch('api/lights');
        const lightsData = await lightsResponse.json();
        this.setState({lights: lightsData});

        const roomsResponse = await fetch('api/rooms');
        const roomsData = await roomsResponse.json();
        this.setState({rooms: roomsData});

        this.setState({loading: false});

    }
    
    getRoomName(id) {
        const room = this.state.rooms.find(f => {
            return f.id === id
        });
        return room.name; 
    }
}
