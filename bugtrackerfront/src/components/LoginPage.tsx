import { Button, Grid, InputAdornment, makeStyles, TextField, Typography } from "@material-ui/core";
import useStyles from "./style/MainStyle";
import EmailIcon from '@material-ui/icons/Email';
import LockIcon from '@material-ui/icons/Lock';
import { Link } from "react-router-dom";
import {useForm} from "../components/useForm"
import { ErrorSharp } from "@material-ui/icons";
import {useAuth} from '../contexts/AuthContext';
import Actions from "./actions/Actions"
import { useState } from "react";


const initialFieldValues = {
    password: "",
    email: ""
}


const useCustomStyles = makeStyles((theme) => ({
    errorParagraph: {
        color: "#DC143C"
    }
}))

function LoginPage() {
    const {currentUser, setCurrentUser} = useAuth();
    const classes = useStyles()
    const customClasses = useCustomStyles()
    const {values, handleInputChange, errors, setErrors} = useForm(initialFieldValues);
    const [loginError, setLoginError] = useState("");

    const validate = () => {
        let temp = {
            email: "",
            password: ""
        }
        temp.email = ((/$^|.+@.+..+/).test(values.email) && values.email.length!=0)?"":"Email is not valid"
        temp.password = values.password.length !== 0?"":"This field is required"
        setErrors({
            ...temp
        })
        return Object.values(temp).every(x=> x === "");
    }
    
    const handleSubmit = (e:any) => {
        e.preventDefault()
        if(validate()){
            Actions.UserActions.login(values)
            .then(res => {
                setLoginError("")
                console.log(res);
                localStorage.setItem('token', res.token);
                /*Actions.UserActions.getUserFromToken()
                .then(res => {
                    setCurrentUser(res);
                })
                .catch(err => {
                    console.log(err);
                })*/

            })
            .catch(err => {
                setLoginError("Email or password are wrong");
                console.log(err);
            })
        }
        
    }

    return (
        <Grid
         container
         className={classes.loginContainer}
        >
            <Grid 
            item 
            xs={12}
            sm={6}
            >
                <img 
                src={process.env.PUBLIC_URL + "/assets/images/loginPageBackground.jpg"} 
                style={{width: "100%", maxHeight: "100vh", objectFit: "cover"}}
                alt="brand"
                />
            </Grid>
            <Grid
            item
            container
            xs={12}
            sm={6}
            alignItems="center"
            direction="column"
            justify="space-evenly"
            >
                <div style={{
                    display: "flex", 
                    flexDirection: "column", 
                    alignItems: "center", 
                    minWidth: 300, 
                    maxWidth: 300
                }}>
                    {/* <Grid
                     container
                     justify="center"
                    ></Grid> */}
                    <form onSubmit={handleSubmit}>
                    <Typography variant="h6">Login here:</Typography>
                    <TextField 
                    label="Email" 
                    name="email"
                    value={values.email}
                    {...(errors.email && {error:true, helperText:errors.email})}
                    onChange={handleInputChange}
                    margin="normal"
                    style={{minWidth: "100%"}}
                    InputProps={{ startAdornment: <InputAdornment position="start"><EmailIcon/></InputAdornment>}}
                    />
                    <TextField 
                    type="password"
                    label="Password"
                    name="password"
                    value={values.password}
                    {...(errors.password && {error:true, helperText:errors.password})}
                    onChange={handleInputChange} 
                    margin="normal"
                    style={{minWidth: "100%"}}
                    InputProps={{ startAdornment: <InputAdornment position="start"><LockIcon/></InputAdornment>}}
                    />
                    {loginError && <p className={customClasses.errorParagraph}>{loginError}</p>}
                    <Button 
                    color="primary" 
                    variant="contained"
                    type="submit"
                    style={{marginTop: "2em", marginBottom: "2em", minWidth: "100%"}}
                    >
                    Login
                    </Button>
                    <Button
                     component={Link}
                     to="/signup"
                    >
                    Interested in joining?
                    </Button>
                    </form>
                </div>
            </Grid>

        </Grid>
    )
}

export default LoginPage