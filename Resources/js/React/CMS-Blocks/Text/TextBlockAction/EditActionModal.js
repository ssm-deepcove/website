﻿import React, { Component, Fragment } from 'react';
import { Button } from '../../../Components/Button';
import TextBlockAction from '../TextBlockAction';
import { Modal } from '../../../Components/Modal';
import { Select, Checkbox } from '../../../Components/FormControl';
import { FormGroup, Input } from '../../../Components/FormControl';
import _ from 'lodash';
import $ from 'jquery';


export default class EditActionModal extends Component {

    constructor(props) {
        super(props);
        this.state = {
            link: _.cloneDeep(this.props.link)
        }
    }

    editVal(field, value) {
        let link = _.cloneDeep(this.state.link);
        switch (field) {
            case 'text':
                link.text = value;
                break;

            case 'href':
                link.href = value;
                break

            case 'align':
                link.align = String(value).toLowerCase();
                break;

            case 'color':
                link.color = String(value).toLowerCase();
                break;

            case 'isButton':
                link.isButton = value;
                break;
        }

        this.setState({
            link: link
        });
    }

    returnChanges() {
        this.props.cb(this.state.link)
        this.toggleModal();
    }

    toggleModal(slot, e) {
        $(`#edit-action-modal-${this.props.slotNo}`).modal(e ? e : 'toggle');
    }

    render() {
        return (
            <Fragment>
                <Button btnClass="btn btn-sm btn-info d-inline" type="button" cb={this.toggleModal.bind(this, this.props.slot)}>
                    {this.props.btnText} &nbsp; <i class="fas fa-cog" />
                </Button>

                <Modal size="large" id={`edit-action-modal-${this.props.slotNo}`} title="Customize link">

                    <div class="row">

                        <div class="col-lg-8">
                            <FormGroup htmlFor="link-text" label="Link Text">
                                <Input type="text" id="link-text" value={this.state.link ? this.state.link.text : undefined} cb={this.editVal.bind(this, 'text')} required />
                            </FormGroup>

                            <FormGroup htmlFor="link-href" label="Link Destination">
                                <Input type="url" id="link-href" value={this.state.link ? this.state.link.href : undefined} cb={this.editVal.bind(this, 'href')} required />
                            </FormGroup>

                            <div class="row">
                                <div class="col-lg-4">
                                    <FormGroup htmlFor="link-color" label="Link Color">
                                        <Select id="link-color"
                                            options={this.props.settings.colors}
                                            selected={this.state.link ? this.state.link.align : null}
                                            cb={this.editVal.bind(this, 'color')} />
                                    </FormGroup>
                                </div>
                                <div class="col-lg-4">
                                    <FormGroup htmlFor="link-align" label="Link Alignment">
                                        <Select id="link-align"
                                            options={this.props.settings.alignments}
                                            selected={this.state.link ? this.state.link.align : null}
                                            cb={this.editVal.bind(this, 'align')} />
                                    </FormGroup>
                                </div>
                                <div class="col-lg-4">
                                    <Checkbox id="link-isButton" label="Show as Button" checked={this.state.link.isButton} cb={this.editVal.bind(this, 'isButton')} />
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-4">
                            <h5 class="text-center">Preview</h5>
                            <TextBlockAction link={this.state.link} />
                        </div>

                    </div>

                    <div class="float-right">
                        <Button btnClass="btn btn-danger mr-2" cb={this.toggleModal.bind(this)}>
                            Cancel &nbsp; <i class="fas fa-times" />
                        </Button>
                        <Button btnClass="btn btn-success" cb={this.returnChanges.bind(this)}>
                            Accept &nbsp; <i class="fas fa-check" />
                        </Button>
                    </div>

                </Modal>
            </Fragment >
        );

    }
}