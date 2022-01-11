import React, { Component } from 'react';
import Employee from './Employee/Employee'

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <div>
                <h1>Employees Benefit Packages Detail</h1>
                <Employee />
            </div>
        );
    }
}
