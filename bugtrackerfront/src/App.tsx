import './App.css';
import useStyles from './components/style/MainStyle';
import { Route } from 'react-router';
import HomePage from './components/HomePage';
import LoginPage from './components/LoginPage';
import SignupPage from './components/SignupPage';
import ProjectsPage from './components/ProjectsPage';
import RequestsPage from './components/RequestsPage';
import UsersPage from './components/UsersPage';
import EditProjectPage from './components/EditProjectPage';
import ProjectPage from './components/ProjectPage';




function App() {
  const classes = useStyles();


  return (
    <div className={classes.root}>
      <Route exact path="/" component={HomePage}/>
      <Route path="/login" component={LoginPage}/>
      <Route path="/signup" component={SignupPage}/>
      <Route exact path="/projects" component={ProjectsPage}/>
      <Route exact path="/projects/:id" component={ProjectPage}/>
      <Route path="/projects/edit/:id" component={EditProjectPage}/>
      <Route path="/requests" component={RequestsPage}/>
      <Route path="/users" component={UsersPage}/>
    </div>
  );
}

export default App;
