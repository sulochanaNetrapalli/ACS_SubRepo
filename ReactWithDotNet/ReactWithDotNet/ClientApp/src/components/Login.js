import React, { Component } from 'react';
import Email from './Email';

export class Login extends Component {
    //static displayName = Home.name;

    render() {
        return (
            <div>
                <input type='email' placeholder='enter user email' ></input>
                <input type='password' placeholder='enter password' ></input>
                <button type='submit'>Login</button>
                {/*<Email />*/}

            </div>
        );
    }
}
