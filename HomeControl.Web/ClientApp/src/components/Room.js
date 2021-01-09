import React, {Component} from 'react';
import {Card, Col, Row} from 'react-bootstrap'
import {withRouter} from "react-router-dom";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faLightbulb, faPlug, faQuestion} from '@fortawesome/free-solid-svg-icons';
import * as DeviceTypes from '../constants/deviceTypes';

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

    getLightDevices(devices) {
        return devices.filter(f => f.typeId === DeviceTypes.Light)
    }

    getOtherDevices(devices){
        return devices.filter(f => f.typeId !== DeviceTypes.Light)
    }

    getDeviceCard(device) {
        let deviceTypeIcon;
        switch (device.typeId) {
            case DeviceTypes.Light:
                deviceTypeIcon = <FontAwesomeIcon icon={faLightbulb} className="primary"/>
                break;
            case DeviceTypes.Outlet:
                deviceTypeIcon = <FontAwesomeIcon icon={faPlug} className="primary"/>
                break;
            default:
                deviceTypeIcon = <FontAwesomeIcon icon={faQuestion} className="primary"/>
                break;
        }

        return (<Card>
            <Card.Header>{device.name}</Card.Header>
            <Card.Body>
                <Row>
                    <Col xs={6}>
                        Typ:
                    </Col>
                    <Col xs={6} className="text-right">
                        {deviceTypeIcon}
                    </Col>
                </Row>
            </Card.Body>
        </Card>)
    }

    render() {
        if (this.state.loading) {
            return null;
        } else if (this.state.error) {
            return <p>Error happened :(</p>
        } else {
            return <>
                <Row className="mt-3">
                    <Col xs={12}>
                        Lampen:
                    </Col>
                </Row>
                <Row>
                    <Col xs={12}>
                        <Row>
                            {this.getLightDevices(this.state.devices).map(device =>
                                <Col xs={3} className="my-3">
                                    {this.getDeviceCard(device)}
                                </Col>
                            )}
                        </Row>
                    </Col>
                </Row>
                <Row className="mt-3">
                    <Col xs={12}>
                        Sonstige:
                    </Col>
                </Row>
                <Row>
                    <Col xs={12}>
                        <Row>
                            {this.getOtherDevices(this.state.devices).map(device =>
                                <Col xs={3} className="my-3">
                                    {this.getDeviceCard(device)}
                                </Col>
                            )}
                        </Row>
                    </Col>
                </Row>
            </>
        }
    }
}

export default withRouter(Room);
