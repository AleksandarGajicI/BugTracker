import useStyles from "./style/MainStyle"
import FormBase from "../components/forms/FormBase";
import CustomInput from "../components/forms/CustomInput";
import CustomDatePicker from "../components/forms/CustomDatePicker";
import { Button, Grid, Typography } from "@material-ui/core";
import { ProjectUpdateDTO } from "./models/dtos/ProjectUpdateDTO";
import { useEffect, useState } from "react";
import { useForm } from "./useForm";
import { useHistory, useParams } from "react-router";
import Layout from "./Layout";
import CustomCheckbox from "./forms/CustomCheckbox";
import Actions from "./actions/Actions";
import { ProjectDTO } from "./models/dtos/ProjectDTO";
import Project from "./models/Project";


const projectDto: ProjectUpdateDTO = {
    ownerId: "",
    name: "",
    deadline: "",
    description: "",
    closed: false
} 

const initialValues = {
    ...projectDto,
    currentDate: new Date()
}

function EditProjectPage() {
    const classes = useStyles()
    const [project, setProject] = useState<ProjectUpdateDTO | null>(null)
    const {values, errors, setErrors, handleInputChange} = useForm(initialValues)
    const {id} = useParams<{id: string}>()
    const history = useHistory()

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

    useEffect(() => {
        console.log(id)
        Actions.ProjectActions.getById(id)
        .then(data => {
            refreshData(data)
        })
    }, [id])

    function refreshData(data: Project) {
        const date = new Date(data.deadline)
        values.name = data.name
        values.description = data.description
        values.deadline = data.deadline
        handleInputChange({target: {name: "currentDate", value: date}})
    }

    function onSubmit() {

        const projectUpdateRequest: ProjectUpdateDTO = {
            ownerId: "8812363d-a71f-4143-7693-08d90b499182",
            name: values.name,
            deadline: values.deadline,
            description: values.description,
            closed: values.closed,
        }

        console.log(projectUpdateRequest)

        Actions.ProjectActions.update(id, projectUpdateRequest)
        .then(data => {
            refreshData(data)
            history.push("/projects")
        })
    }

    return (
        <Layout>
            <FormBase>
            <Grid 
             item 
             xs={12}
             container
             justify="center"
            >
                <Typography variant="h5">Edit Project</Typography>
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
                <CustomCheckbox
                 name="closed"
                 label="Closed:"
                 onChange={handleInputChange}
                 value={values.closed}
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
                        SAVE CHANGES
                </Button>
            </Grid>
        </FormBase>
    </Layout>
    )
}

export default EditProjectPage