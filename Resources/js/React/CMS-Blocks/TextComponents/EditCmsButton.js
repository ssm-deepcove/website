﻿import React, { Component, Fragment } from 'react';
import { FormGroup, Input, Select } from '../../Components/FormControl';
import { Button } from '../../Components/Button';
import { isExternalUrl } from '../../../helpers';
import Modal from '../../Components/Modal';

export default class EditCmsButton extends Component {
    constructor(props) {
        super(props);

        this.state = {
            button: this.props.button || {
                id: 0,
                align: "left",
                color: "dark",
                href: "",
                text: ""
            },
            showModal: false
        }
    }

    editVal(field, value) {
        let button = this.state.button;
        button[field] = value;
        this.setState({
            button: button
        });
    }

    returnChanges(e) {
        e.preventDefault();
        this.props.onSave(this.state.button);
    }

    render() {
        if (!this.props.settings) return;

        let deleteOption = this.props.button ? (
            <a className="dropdown-item" role="presentation" onClick={this.props.onDelete}>
                Delete Button <i className="fas fa-exclmation-triangle text-danger" />
            </a>
        ) : null;

        let externalIcon = this.state.button && isExternalUrl(this.state.button.href) ? <i className="fas fa-external-link-alt"/>: null;
        
        let modal = this.state.showModal ? (
            <Modal title="Configure Button" handleHideModal={() => this.setState({ 'showModal': false })}>
                <form onSubmit={this.returnChanges.bind(this)}>
                    <div className="row text-left">
                        <div className="col-12">
                            <FormGroup label="Button Text: " required>
                                <Input cb={this.editVal.bind(this, 'text')} type="text" value={this.state.button.text} maxLength="30" required />
                                <small className="float-right">(max 30 chars)</small>
                            </FormGroup>

                            <FormGroup label="URL: " required>
                                <Input placeHolder="https://" type="href" cb={this.editVal.bind(this, 'href')} value={this.state.button.href} required />
                                <p className="my-2">Or create a download link <span className="font-italic">(Coming Sooon!)</span></p>
                                <Button className="btn btn-dark" disabled>
                                    Choose File <i className="fas fa-file-check" />
                                </Button>
                            </FormGroup>
                        </div>

                        <div className="col-lg-6 col-md-12">
                            <FormGroup label="Select Color">
                                <Select cb={this.editVal.bind(this, 'color')}
                                    options={this.props.settings.color}
                                    selected={this.state.button.color} />
                            </FormGroup>
                        </div>

                        <div className="col-lg-6 col-md-12">
                            <FormGroup label="Alignment">
                                <Select cb={this.editVal.bind(this, 'align')}
                                    options={this.props.settings.align}
                                    selected={this.state.button.align} />
                            </FormGroup>
                        </div>

                        <div className="col-9 text-center px-3">
                            <p className="mt-2 float-left">Preview &nbsp; &nbsp;</p>
                            <Button className={`btn btn-${this.state.button.color}`}>
                                {this.state.button.text} &nbsp;
                                    {externalIcon}
                            </Button>
                        </div>

                        <div className="col-3 text-right">
                            <Button className="btn btn-success" type="submit">Done</Button>
                        </div>
                    </div>
                </form>
            </Modal>
        ) : null

        return (
            <Fragment>
                <div className="dropdown d-inline ml-1">
                    <button className="btn btn-dark btn-sm dropdown-toggle" data-toggle="dropdown" aria-expanded="false" type="button">
                        <i className="fas fa-cogs" />
                    </button>

                    <div className="dropdown-menu" role="menu">
                        <a className="dropdown-item" role="presentation" onClick={() => this.setState({ 'showModal': true })}>Configure Button</a>
                        {deleteOption}
                    </div>
                </div>

                {modal}
            </Fragment>
        )
    }
}