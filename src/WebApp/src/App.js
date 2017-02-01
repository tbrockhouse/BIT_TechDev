import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';

class App extends Component {
  render() {
    return (
      <div className="App">
        <div className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h2>Welcome to React</h2>
        </div>
        <p className="App-intro">
          To get started, edit <code>src/App.js</code> and save to reload.
        </p>
      </div>
    );
  }
}

class TaskList extends Component {

  constructor(props) {
    super(props);

    this.state = {
      data: []
    };
  }

  componentDidMount() {
    axios.get('http://api.fixer.io/latest')
      .then(result => {
        let data = []
        for(var key in result.data.rates) {
          data.push(result.data.rates[key]);
        }
        this.setState({ data: data })
      });
  }

  render() {
    return (
          <div className="taskList">
            {this.state.data}
          </div>
        );
  }
}

export {App, TaskList};