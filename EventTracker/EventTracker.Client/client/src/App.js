import React from 'react';
import './App.css';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Home from './components/Home/Home';
import Auth from './components/Auth/Auth';
import Admin from './components/Admin/Admin';

function App() {
  return (
    <div className="App">
      <Router>
        <Switch>
          <Route exact path="/" component={Home} />
          <Route path="/auth" component={Auth} />
          <Route path="/admin" component={Admin} />
        </Switch>
      </Router>
    </div>
  );
}

export default App;
