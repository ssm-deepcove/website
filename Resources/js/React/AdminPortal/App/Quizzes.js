﻿import React, { Component, Fragment } from 'react';
import { render } from 'react-dom';

import Alert from '../../Components/Alert';
import QuizIndex from './Quizzes/QuizIndex';
import QuizDetails from './Quizzes/QuizDetails';

export default class Quizzes extends Component {

    constructor(props) {
        super(props);

        this.state = {
            selectedQuizId: null,
            selectedQuizTitle: null
        }
    }

    componentDidMount() {
        this.setState({});
    }

    onQuizSelect(selectedQuizId, selectedQuizTitle) {
        this.setState({
            selectedQuizId,
            selectedQuizTitle
        })
    }

    onClearSelected() {
        this.setState({
            selectedQuizId: null,
            selectedQuizTitle: null
        })
    }

    // On clicking the 'add new' button
    onQuizAdd() {
        this.setState({
            selectedQuizId: 0,
            selectedQuizTitle: "Add New Quiz"
        })
    }

    // User saves changes to a quiz/questions
    onQuizSave(quizId, quizTitle) {
        this.setState({
            selectedQuizId: quizId,
            selectedQuizTitle: quizTitle
        })
    }

    render() {

        let page = this.state.selectedQuizId == null
            ? <QuizIndex alert={this.Alert} onSelect={this.onQuizSelect.bind(this)} onAdd={this.onQuizAdd.bind(this)} />
            : <QuizDetails alert={this.Alert} quizId={this.state.selectedQuizId} quizTitle={this.state.selectedQuizTitle} onQuizSave={this.onQuizSave.bind(this)} onBack={this.onClearSelected.bind(this)} />

        return (
            <Alert onRef={ref => this.Alert = ref}>
                <h1 className="text-center my-5">Quiz Management</h1>
                {page}
            </Alert>
        );
    }
}

if (document.getElementById('react_app_quizzes')) {
    render(<Quizzes />, document.getElementById('react_app_quizzes'));
}