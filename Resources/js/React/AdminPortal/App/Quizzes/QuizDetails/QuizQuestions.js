﻿import React, { Component, Fragment } from 'react';
import $ from 'jquery';

import { FormGroup, Input, Checkbox, TextArea, Select } from '../../../../Components/FormControl';
import SelectMedia from '../../../../CMS-Blocks/SelectMedia';
import { Button } from '../../../../Components/Button';
import Card, { CardHighlight, CardBody } from '../../../../Components/Card';
import AudioControls from '../../../../Components/Audio';
import Modal from '../../../../Components/Modal';
import OverlayImage from '../../../../Components/OverlayImage';

export default class QuizQuestions extends Component {
    render() {
        let questionCards = this.props.questions.map((q, index) => {
            return (
                <QuestionCard key={q.id}
                    questionNo={index + 1} question={q}
                    pendingEdit={this.props.pendingEdit}
                    onHover={this.props.onHover.bind(this, index)}
                    onEdit={this.props.onEdit.bind(this, index)}
                    onUpdateQuestion={this.props.onUpdateQuestion.bind(this, index)}
                    onShiftQuestion={this.props.onShiftQuestion.bind(this, q.id)}
                    onDeleteQuestion={this.props.onDeleteQuestion.bind(this, index)}
                    onCancel={this.props.onCancel}
                    onSave={this.props.onSaveQuestion} />
            )
        })

        questionCards.push(<NewQuestionCard key="9999" pendingEdit={this.props.pendingEdit} onAdd={this.props.onAddQuestion} />)

        return (
            <Card className="bg-trans">
                <CardHighlight>
                    <h3 className="mt-3">Questions</h3>
                </CardHighlight>

                {this.props.mustSaveSettingsFirst ? <h5 className="text-center mt-4 mb-0">Save the above details to start building the quiz.</h5> : null}

                <CardBody>
                    {questionCards}
                </CardBody>
            </Card>
        )
    }
}

class QuestionCard extends Component {

    constructor(props) {
        super(props);

        this.state = {
            showDeleteModal: false,
            showImageSelectModal: false,
            showAudioSelectModal: false,
            editMode: this.props.question.id == 0
        }
    }

    componentDidMount() {
        $('.d-square').each(() => { $(this).css('height', $(this).offsetWidth) });
    }

    onCancel() {
        this.props.onCancel();
        this.setState({
            editMode: false,
            showDeleteModal: false,
        })
    }

    onEdit() {
        this.setState({
            editMode: true
        })
        this.props.onEdit();
    }

    handleFormSubmit(e) {
        e.preventDefault();
        this.props.onSave(() => this.setState({ editMode: false }));
    }

    onClickDelete() {
        this.setState({
            showDeleteModal: true
        })
    }

    onUpdateAnswer(ansIndex, key, val) {
        let answer = this.props.question.answers[ansIndex];
        answer[key] = val;
        this.props.onUpdateQuestion('answers', answer, ansIndex);
    }

    render() {

        let disabled = !this.state.editMode;

        let answerStyleOptions = ['Text Answers', 'Image Answers', 'True Or False'].map((style, index) => {
            return <option key={index} value={style.replace(/\s/g, '')}>{style}</option>
        })

        let questionAudio = this.props.question.audio
            ? (
                <Fragment>
                    <span className="font-weight-bold">Audio</span>
                    <div className="position-relative text-center">
                        <AudioControls className="mb-2 w-75" file={this.props.question.audio} />
                        {!disabled ? <Button className="btn btn-gray vertically-center" cb={this.props.onUpdateQuestion.bind(this, 'audio', null)}><i className="fas fa-times"></i></Button> : null}
                    </div>
                </Fragment>
            )
            : !disabled ? (
                <div onClick={() => this.setState({ showAudioSelectModal: true })} className="new-something-card text-center" style={{ maxHeight: "80px" }}>
                    <div><i className="far fa-plus-square fa-2x d-block"></i><small>Add Audio Clip</small></div>
                </div>
            ) : null

        let answerTiles;
        if (this.props.question.questionType == "TrueOrFalse") {
            let answers = ['False', 'True'];
            answerTiles = answers.map((a, i) => {
                return <AnswerTile key={i} type="TrueOrFalse" answerNo={i + 1} questionNo={this.props.questionNo} disabled={disabled} answer={a} isCorrect={this.props.question.trueFalseAnswer == i} />
            })
        }
        else {
            answerTiles = this.props.question.answers.map((a, i) => {
                return <AnswerTile key={i}
                    type={this.props.question.questionType} answerNo={i}
                    questionNo={this.props.questionNo} disabled={disabled}
                    answer={a} isCorrect={this.props.question.correctAnswerIndex == i}
                    onUpdate={this.onUpdateAnswer.bind(this, i)}
                />
            });
        }

        let isTF = this.props.question.questionType == "TrueOrFalse";

        let trueFalseAnswerOptions = [{ value: 0, label: 'False' }, { value: 1, label: 'True' }];
        let answerOptions = [{ value: 0, label: 'Answer 1' }, { value: 1, label: 'Answer 2' }, { value: 2, label: 'Answer 3' }, { value: 3, label: 'Answer 4' }];
        let correctAnswerOptions = this.props.question.questionType == 'TrueOrFalse' ? trueFalseAnswerOptions : answerOptions;

        let controls = (
            <div className="text-center pt-3 pb-2">
                <Button className="btn btn-danger mr-2" cb={this.onCancel.bind(this)}>Discard Changes</Button>
                <Button className="btn btn-success" type="submit">Save Changes</Button>
            </div>
        )

        let deleteQuestionModal = this.state.showDeleteModal ? (
            <Modal handleHideModal={() => { this.setState({ showDeleteModal: false }) }}>
                <h5 className="text-left">
                    <i className="far fa-exclamation-triangle pr-3"></i>
                    Are you sure you want to delete this question?
                    </h5>
                <hr className="pb-2" />

                <FormGroup>
                    <Button className="btn btn-danger float-right btn-sm" dismiss="modal"
                        cb={this.props.onDeleteQuestion}
                    >
                        Delete
                    </Button>

                    <Button className="btn btn-dark float-right btn-sm mx-1" dismiss="modal">No</Button>
                </FormGroup>
            </Modal>
        ) : null

        let imageWarning = this.props.question.image && this.props.question.questionType == "ImageAnswers"
            ? <small className="font-weight-bold text-danger">Question image will not display with image answers</small>
            : null;

        return (
            <div onMouseEnter={this.props.onHover}>
                <Card className="question-card">
                    <CardHighlight>
                        <h5 className="mt-3 mb-2">{`Question ${this.props.questionNo}`}</h5>
                        <div className={`dropdown ${this.props.pendingEdit ? 'd-none' : ''}`}>
                            <button className="btn dropdown-toggle text-white" type="button" data-toggle="dropdown"></button>
                            <ul className="dropdown-menu">
                                <li onClick={this.onEdit.bind(this)}><i className="fas fa-pencil"></i> &nbsp; Edit</li>
                                <li onClick={this.props.onShiftQuestion.bind(this, true)}><i className="fas fa-chevron-up"></i> &nbsp; Move Up</li>
                                <li onClick={this.props.onShiftQuestion.bind(this, false)}><i className="fas fa-chevron-down"></i> &nbsp; Move Down</li>
                                <li onClick={this.onClickDelete.bind(this)}><i className="fas fa-trash"></i> &nbsp; Delete</li>
                            </ul>
                        </div>
                        {deleteQuestionModal}
                    </CardHighlight>
                    <form onSubmit={(e) => { this.handleFormSubmit(e) }}>
                        {this.state.editMode ? controls : null}
                        <div className="row p-2">
                            <div className="col-sm-7">
                                <FormGroup htmlFor={`question-${this.props.question.id}-text`} label="Question" required>
                                    <TextArea cb={this.props.onUpdateQuestion.bind(this, 'text')} rows="3" inputClass="form-control resize-none" id={`question-${this.props.question.id}-text`} value={this.props.question.text} disabled={disabled} required />
                                </FormGroup>

                                {questionAudio}

                                <QuestionImage cb={() => this.setState({ showImageSelectModal: true })} onClear={this.props.onUpdateQuestion.bind(this, 'image', null)} displayClass="d-sm-none" image={this.props.question.image} disabled={disabled} />

                                <FormGroup htmlFor={`question-${this.props.question.id}-style`} className="mt-2" label="Answers Style" required>
                                    <Select cb={this.props.onUpdateQuestion.bind(this, 'questionType')} id={`question-${this.props.question.id}-style`} formattedOptions={answerStyleOptions} disabled={disabled} required selected={this.props.question.questionType} />
                                </FormGroup>

                                {imageWarning}

                                <FormGroup htmlFor={`question-${this.props.question.id}-correct-answer`} className="mt-2" label="Correct Answer" required>
                                    <Select cb={this.props.onUpdateQuestion.bind(this, isTF ? 'trueFalseAnswer' : 'correctAnswerIndex')} id={`question-${this.props.question.id}-correct-answer`} options={correctAnswerOptions} disabled={disabled} required selected={isTF ? this.props.question.trueFalseAnswer : this.props.question.correctAnswerIndex} />
                                </FormGroup>
                            </div>
                            <div className="col-sm-5">
                                <QuestionImage cb={() => this.setState({ showImageSelectModal: true })} onClear={this.props.onUpdateQuestion.bind(this, 'image', null)} displayClass="d-none d-sm-block" image={this.props.question.image} disabled={disabled} />
                            </div>
                        </div>
                        <div className="row mt-3">
                            {answerTiles}
                        </div>
                        {this.state.editMode || this.props.question.id == 0 ? controls : null}
                    </form>

                    <SelectMedia
                        type="Image"
                        cb={(imageData) => { this.props.onUpdateQuestion('image', imageData) }}
                        showModal={this.state.showImageSelectModal}
                        handleHideModal={() => this.setState({ showImageSelectModal: false })}
                    />

                    <SelectMedia
                        type="Audio"
                        cb={(audioData) => { this.props.onUpdateQuestion('audio', audioData) }}
                        showModal={this.state.showAudioSelectModal}
                        handleHideModal={() => this.setState({ showAudioSelectModal: false })}
                    />
                </Card>
            </div>
        )
    }
}

class NewQuestionCard extends Component {
    render() {
        return this.props.pendingEdit ? <div></div> : (
            <div>
                <div className="w-100 my-2 new-question-card card text-center" onClick={this.props.onAdd}>
                    <i className="far fa-plus-square fa-5x"></i>
                </div>
            </div>
        )
    }
}

class QuestionImage extends Component {

    render() {
        let imageSource = this.props.image ? `/media?filename=${this.props.image.filename}` : '/images/no-image.png';

        let image = (
            <OverlayImage cb={this.props.cb}
                imageSource={imageSource}
                enabled={!this.props.disabled}>
                <h5 className="text-white text-center pt-3 pb-2 bg-dark-trans w-90">{this.props.image ? 'Click to change' : 'Click to add'}</h5>
            </OverlayImage>
        )

        return (
            <div className={`bground-primary text-white text-center position-relative ${this.props.displayClass}`}>
                {this.props.disabled ? null : <Button className="btn btn-gray bground-primary pos-top-right" cb={this.props.onClear}><i className="fas fa-times"></i></Button>}
                <p className="mt-2 pt-4 pb-1 font-weight-bold bground-primary">Question Image</p>
                {image}
            </div>
        )
    }
}

class AnswerTile extends Component {

    constructor(props) {
        super(props);

        this.state = {
            showModal: false
        }
    }

    setModal(showModal) {
        this.setState({
            showModal
        })
    }

    render() {

        let tile = <div></div>;

        if (this.props.type == "TextAnswers") {
            tile = (
                <div className="col-md-6">
                    <div className={`card answer-tile m-2 ${this.props.isCorrect ? 'bground-primary text-white' : ''}`}>
                        <FormGroup htmlFor={`question-${this.props.questionNo}-answer-${this.props.answerNo}`} className="mt-2 ml-2 text-center" label={`Answer ${this.props.answerNo + 1}`}>
                            <Input cb={this.props.onUpdate.bind(this, 'text')} type="text" id={`question-${this.props.questionNo}-answer-${this.props.answerNo}`} inputClass="mx-auto" value={this.props.answer.text} disabled={this.props.disabled} required />
                        </FormGroup>
                    </div>
                </div>
            )
        }

        if (this.props.type == "ImageAnswers") {
            tile = (
                <div className="col-md-6">
                    <div className={`card answer-tile m-2 ${this.props.isCorrect ? 'bground-primary text-white' : ''}`}>
                        <div className="row">
                            <div className="col-7">
                                <FormGroup htmlFor={`question-${this.props.questionNo}-answer-${this.props.answerNo}`} className="mt-2 ml-2 text-center" label={`Answer ${this.props.answerNo + 1}`}>
                                    <Input cb={this.props.onUpdate.bind(this, 'text')} type="text" id={`question-${this.props.questionNo}-answer-${this.props.answerNo}`} inputClass="mx-auto w-90" value={this.props.answer.text} disabled={this.props.disabled} />
                                </FormGroup>
                            </div>
                            <div className="col-5">
                                <OverlayImage cb={this.props.disabled ? null : this.setModal.bind(this, true)}
                                    imageSource={this.props.answer.image ? `/media?filename=${this.props.answer.image.filename}` : '/images/no-image.png'}
                                    enabled={!this.props.disabled}>
                                    <h5 className="text-white text-center pt-3 pb-2 bg-dark-trans w-90">{this.props.answer.image ? 'Change' : 'Add'}</h5>
                                </OverlayImage>
                                <SelectMedia
                                    type="Image"
                                    cb={(imageData) => { this.props.onUpdate('image', imageData) }}
                                    showModal={this.state.showModal}
                                    handleHideModal={this.setModal.bind(this, false)}
                                />
                            </div>
                        </div>
                    </div>
                </div>
            )
        }

        return tile;
    }
}

