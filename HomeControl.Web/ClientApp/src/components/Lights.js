import React, { Component } from 'react';

export class Lights extends Component {
    static displayName = Lights.name;

    constructor(props) {
        super(props);
        this.state = { lights: [], loading: true };
    }

    componentDidMount() {
        this.getLightsData();
    }

    static renderLightsTable(lights) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                <tr>
                    <th>Name</th>
                    <th>State</th>
                </tr>
                </thead>
                <tbody>
                {lights.map(light =>
                    <tr key={light.id}>
                        <td>{light.name}</td>
                        <td>{light.state.on.toString()}</td>
                    </tr>
                )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Lights.renderLightsTable(this.state.lights);

        return (
            <div>
                <h1 id="tabelLabel" >Lights</h1>
                {contents}
            </div>
        );
    }

    async getLightsData() {
        const response = await fetch('api/lights');
        const data = await response.json();
        this.setState({ lights: data, loading: false });
    }
}
