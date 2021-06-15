import { Button, Grid, Typography } from "@material-ui/core";
import Project from "../models/Project";
import useStyles from "../style/MainStyle";
import { useForm } from "../useForm";
import FormBase from "./FormBase";
import CustomInput from "./CustomInput";
import CustomDatePicker from "./CustomDatePicker";
import { CreateProjectRequest } from "../models/project/CreateProjectRequest";
import Actions from "../actions/Actions";

const project: Project = {
    id: "",
    name: "",
    description: "",
    deadline: ""
}

const initialValues = {
    ...project,
    currentDate: new Date()
}


function ProjectForm() {
    const classes = useStyles();
    const {values, errors, setErrors, handleInputChange} = useForm(initialValues);

    const validate = () => {
        const temp = {...project};
        temp.name = values.name || values.name.length !== 0? "" : "This field is required!";
        temp.name = values.name.length > 200 ? "Project name must contain less than 200 characters" : temp.name;
        temp.description = values.description.length > 350 ? "Project description must contain less than 350 characters" : "";
        temp.deadline = values.deadline.length.length === 0? "This field is required" : "";
        //temp.deadline = values.currentDate === ;
        setErrors({
            ...temp
        });

        return Object.values(temp).every(x => x === "");
    }

    function onSubmit() {
        const createRequest: CreateProjectRequest = {
            Name: values.name,
            Description: values.description,
            Deadline: values.currentDate,
            OwnerId: "fc4b7091-f294-4428-bc85-6e0ce1351f7d"
        }

        console.log(createRequest)

        Actions.ProjectActions.create(createRequest)
        .then(data => {
            console.log(data)
        })
        .catch(error => console.log(error))
    }

    return (
        <FormBase>
            <Grid 
             item 
             xs={12}
             container
             justify="center"
             style={{margin: "20px"}}
            >
                <Typography 
                variant="h5"
                >
                    Make New Project
                </Typography>
            </Grid>
            <Grid 
             item 
             xs={6}
             container
             direction="column"
            >
                <CustomInput
                 name="name"
                 label="Project Name"
                 value={values.name}
                 onChange={handleInputChange}
                 type="singleLine"
                 error={errors.name}
                />
                <CustomInput
                 label="Project Description"
                 value={values.description}
                 type="multiLine"
                 name="description"
                 onChange={handleInputChange}
                 error={errors.description}
                />
            </Grid>
            <Grid 
                item 
                xs={6}
                container
                justify="center"
            >
                <CustomDatePicker
                 name="deadline"
                 label="Enter deadline"
                 value={values.currentDate}
                 onChange={handleInputChange}
                 currentDate="currentDate"
                />
            </Grid>
            <Grid 
                item 
                xs={12}
                classes={{root: classes.formRow}}
                container
                alignItems="stretch"
            >
                <Button 
                 color="primary" 
                 variant="contained" 
                 fullWidth={true}
                 onClick={() => {onSubmit()}}
                >
                        MAKE NEW PROJECT
                </Button>
            </Grid>
        </FormBase>
    );
}

export default ProjectForm;
