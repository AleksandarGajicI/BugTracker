import { Button, Grid, Typography } from "@material-ui/core";
import { useEffect } from "react";
import { useState } from "react";
import Actions from "../actions/Actions";
import { ProjectUserReqCreateDTO } from "../models/dtos/ProjectUserReqCreateDTO";
import { useForm } from "../useForm";
import CustomInput from "./CustomInput";
import CustomSelect from "./CustomSelect";
import FormBase from "./FormBase";

interface Props {
    title: string,
    cancel: () => void,
    submit: (req: ProjectUserReqCreateDTO) => void
}

const initialValues: ProjectUserReqCreateDTO = {
    senderId: "",
    userAssignedId: "",
    projectId: "",
    roleId: "",
    message: "",
}

function ProjectUserReqForm(props: Props) {
    const [projectsSelect, setProjectsSelect] = useState<{id: string, name: string}[]>([])
    const [roleSelect, setRoleSelect] = useState<{id: string, name: string}[]>([])
    const {values, errors, setErrors, handleInputChange} = useForm(initialValues);

    useEffect(() => {
        Actions.ProjectActions.all()
        .then(projects => {
            setProjectsSelect(
                projects.map(project => {
                    return {
                        name: project.name,
                        id: project.id
                    }
                })
            )
        })

        Actions.RoleActions.all()
        .then(roles => {
            setRoleSelect(
                roles.map(role => {
                    return {
                        id: role.id,
                        name: role.roleName
                    }
                })
            )
        })
    }, [])

    function submit() {
        props.submit({
            message: values.message,
            projectId: values.projectId,
            roleId: values.roleId,
            senderId: values.senderId,
            userAssignedId: values.userAssignedId
        })
    }

    function onCancel() {
        handleInputChange({
            target: {
                name: "projectId",
                value: ""
            }
        })
        handleInputChange({
            target: {
                name: "roleId",
                value: ""
            }
        })
        handleInputChange({
            target: {
                name: "message",
                value: ""
            }
        })
        props.cancel()
    }


    return (
        <FormBase>
            <Grid
            container
            item
            justify="space-between"
            xs={12}
            style={{padding: "20px"}}
            >
                <Typography 
                variant="h5"
                >
                    {props.title}
                </Typography>
                <Button 
                variant="contained" 
                size="small" 
                color="secondary"
                onClick={() => onCancel()}>
                    CANCEL
                </Button>
            </Grid>
            <Grid
            container
            item
            xs={12}
            md={12}
            direction="column"
            alignItems="center"
            style={{padding: "10px"}}
            >
                <CustomInput
                 name="message"
                 label="Request message"
                 value={values.name}
                 onChange={handleInputChange}
                 type="singleLine"
                 error={errors.name}
                />
                <CustomSelect 
                title="Select Project"
                name="projectId"
                values={projectsSelect}
                onChange={handleInputChange}
                />
                <CustomSelect 
                title="Select Role"
                name="roleId"
                values={roleSelect}
                onChange={handleInputChange}
                />
            </Grid>
            <Grid 
                item 
                xs={12}
                container
                alignItems="stretch"
            >
                <Button 
                 color="primary" 
                 variant="contained" 
                 fullWidth={true}
                 style={{margin: "20px"}}
                 onClick={() => {submit()}}
                >
                        SEND REQUEST
                </Button>
            </Grid>
        </FormBase>
    )
}

export default ProjectUserReqForm