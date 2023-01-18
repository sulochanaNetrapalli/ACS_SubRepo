import React, { Component } from 'react';
import Email from './Email';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h1>Hello, world!</h1>
            <Email/>

        </div>
    );
  }
}
