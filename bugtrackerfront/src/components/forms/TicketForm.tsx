import { Button, Grid, Typography } from "@material-ui/core"
import { useState } from "react";
import { useEffect } from "react";
import Actions from "../actions/Actions";
import { TicketCreateDTO } from "../models/dtos/TicketCreateDTO";
import { TicketDTO } from "../models/dtos/TIcketDTO";
import { useForm } from "../useForm";
import CustomDatePicker from "./CustomDatePicker";
import CustomInput from "./CustomInput"
import CustomSelect from "./CustomSelect";
import FormBase from "./FormBase"

const ticket: TicketCreateDTO = {
    title: "",
    deadline: "",
    projectId: "",
    statusId: "",
    reporterId: "",
    ticketType: "",
    description: "",
}

const initialValues = {
    ...ticket,
    currentDate: new Date()
}

//UNDEFINED, BUG_ERROR, FEATURE_REQUEST, OTHER, DOCUMENT_REQUEST
const ticketTypes = [
    { id: "UNDEFINED", name: "UNDEFINED"},
    { id: "BUG_ERROR", name: "BUG_ERROR"},
    { id: "FEATURE_REQUEST", name: "FEATURE_REQUEST"},
    { id: "DOCUMENT_REQUEST", name: "DOCUMENT_REQUEST"},
    { id: "OTHER", name: "OTHER"},
]

interface Props {
    title: string
    buttonTitle: string,
    ticket?: TicketDTO
}

function TicketForm(props: Props) {
    const {values, errors, setErrors, handleInputChange} = useForm(initialValues);
    const [projectsSelect, setProjectsSelect] = useState<{id: string, name: string}[]>([])
    const [statusSelect, setStatusSelect] = useState<{id: string, name: string}[]>([])

    if(props.ticket) {
        console.log(props.ticket)
    }

    function onSubmit() {
        console.log(values)
    }

    useEffect(() => {
        Actions.ProjectActions.all()
        .then(projects => {
            setProjectsSelect(
                projects.map(project=> {
                    return {
                        id: project.id,
                        name: project.name
                    }
                })
            )
            
        })
        Actions.TicketStatusActions.all()
        .then(statuses => {
            setStatusSelect(
                statuses.map(status => {
                    return {
                        id: status.id,
                        name: status.status
                    }
                })
            )
        })

        if(props.ticket) {
            values.title = props.ticket.title
            values.deadline = props.ticket.deadline
            // values.projectId = props.ticket.projectId
            // values.statusId = props.ticket.statusId
            // values.reporterId = props.ticket.reporterId
            // values.ticketType = props.ticket.ticketType
            values.description = props.ticket.description
        }
    }, [])

    return (
        <FormBase>
            <Grid
            container
            item
            justify="center"
            xs={12}
            style={{padding: "20px"}}
            >
                <Typography 
                variant="h5"
                >
                    {props.title}
                </Typography>
            </Grid>
            <Grid
            container
            item
            xs={12}
            md={6}
            direction="column"
            alignItems="center"
            style={{padding: "10px"}}
            >
                <CustomInput
                 name="title"
                 label="Ticket title"
                 value={values.name}
                 onChange={handleInputChange}
                 type="singleLine"
                 error={errors.name}
                />

                <CustomInput
                 name="description"
                 label="Ticket description"
                 value={values.name}
                 onChange={handleInputChange}
                 type="singleLine"
                 error={errors.name}
                />
                <CustomDatePicker
                 name="deadline"
                 label="Enter deadline"
                 value={values.currentDate}
                 onChange={handleInputChange}
                 currentDate="currentDate"
                />
            </Grid>
            <Grid
            container
            xs={12}
            md={6}
            direction="column"
            alignItems="center"
            justify="center"
            style={{ padding: "10px"}}
            >
                <CustomSelect 
                title="Select Project"
                name="projectId"
                values={projectsSelect}
                onChange={handleInputChange}
                />
                <CustomSelect 
                title="Select Ticket Status"
                name="statusId"
                values={statusSelect}
                onChange={handleInputChange}
                />
                <CustomSelect 
                title="Select Ticket Type"
                name="ticketType"
                values={ticketTypes}
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
                 onClick={() => onSubmit()}
                >
                        {props.buttonTitle}
                </Button>
            </Grid>
        </FormBase>
    )
}

export default TicketForm