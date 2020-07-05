﻿import React, {Component} from 'react';
import {Card, Col, Row} from 'react-bootstrap'
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faCheckCircle, faTimesCircle} from '@fortawesome/free-solid-svg-icons';

export class Lights extends Component {
    static displayName = Lights.name;

    constructor(props) {
        super(props);
        this.state = {lights: [], loading: true};
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
                                                    <FontAwesomeIcon icon={faCheckCircle} className="primary active-device"/> :
                                                    <FontAwesomeIcon icon={faTimesCircle} className="inactive-device"/>}
                                                </p>
                                            </Col>
                                        </Row>
                                        <Row>
                                            <Col xs={6}>
                                                <p>Raum:</p>
                                            </Col>
                                            <Col xs={6} className={'text-right'}>
                                                <p>{light.roomId}</p>
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
        const response = await fetch('api/lights');
        const data = await response.json();
        this.setState({lights: data, loading: false});
    }
}
