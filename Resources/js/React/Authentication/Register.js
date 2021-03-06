﻿import React, { Component } from 'react';
import { render } from 'react-dom';
import { Button } from '../Components/Button';
import { FormGroup, Input } from '../Components/FormControl';
import Alert from '../Components/Alert';
import $ from 'jquery';

const baseUri = "/register";

export default class Register extends Component {
    constructor(props) {
        super(props);

        this.state = {
            requestPending: false
        }
    }

    attemptRegistration(e) {
        e.preventDefault();

        this.setState({
            requestPending: true
        });

        $.ajax({
            type: 'post',
            url: `${baseUri}`,
            data: $("#register").serialize()
        }).done((url) => {
            window.location.replace(url);
        }).fail((err) => {
            this.setState({
                requestFailed: err.responseText,
                requestPending: false
            }, () => this.Alert.error(null, err.responseText));
        })
    }

    render() {
        return (
            <Alert onRef={(ref) => (this.Alert = ref)}>
                <div className="login-clean text-center">
                    <form id="register" onSubmit={this.attemptRegistration.bind(this)}>
                        <h1 className="sr-only">Login Form</h1>
                        <h1 className="display-4 mb-5">Create a New User</h1>

                        <FormGroup>
                            <Input type="text" name="name" placeHolder="Name" autoComplete="name" autoFocus required />
                        </FormGroup>

                        <FormGroup>
                            <Input type="email" name="email" placeHolder="Email" autoComplete="email" required />
                        </FormGroup>

                        <p className="text-dark">
                            The user will be emailed their login information.
                        </p>

                        <FormGroup>
                            <Button className={`btn btn-primary btn-block`} type="submit" pending={this.state.requestPending}>Create Account</Button>
                        </FormGroup>
                    </form>
                </div>
            </Alert>
        );
    }
}


if (document.getElementById('react_register'))
    render(<Register />, document.getElementById('react_register'));