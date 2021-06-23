import { Button, Grid, Typography } from "@material-ui/core"
import { useState } from "react";
import { useEffect } from "react";
import { useHistory } from "react-router-dom";
import Actions from "../actions/Actions";
import { HeadersBuilder } from "../actions/HeadersBuilder";
import Loading from "../Loading";
import { TicketCreateDTO } from "../models/dtos/TicketCreateDTO";
import { TicketDTO } from "../models/dtos/TIcketDTO";
import { TicketUpdateDTO } from "../models/dtos/TicketUpdateDTO";
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
    ticketType: "",
    description: "",
}

const initialValues = {
    ...ticket,
    currentDate: new Date()
}

//UNDEFINED, BUG_ERROR, FEATURE_REQUEST, OTHER, DOCUMENT_REQUEST
const ticketTypes = [
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
    const [loading, setLoading] = useState(true)
    const headerBuilder = new HeadersBuilder()
    const history = useHistory()


    useEffect(() => {
        
        if(!localStorage.getItem("token")) {
            history.push("/")
        }

        headerBuilder.resetHeaders()
        .addHeader("Authorization", `Bearer ${localStorage.getItem("token")}`)
        Promise.all([
            Actions.ProjectActions.all(headerBuilder.getHeaders())
            .then(projects => {
                setProjectsSelect(
                    projects.map(project=> {
                        return {
                            id: project.id,
                            name: project.name
                        }
                    })
                )
                
            }),
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
        ]).then(() => {
            if(props.ticket) {
                console.log(props.ticket.title)
                values.title = props.ticket.title
                values.description = props.ticket.description
                values.deadline = props.ticket.deadline
                values.statusId = props.ticket.status.id
                values.ticketType = props.ticket.type
    
            }
            setLoading(false)
        })
        
    }, [])


    function onSubmit() {
        //TODO validation of input!
        if(!props.ticket) {
            headerBuilder.resetHeaders()
            .addHeader("Authorization", `Bearer ${localStorage.getItem("token")}`)

            const createReq: TicketCreateDTO = {
                title: values.title,
                deadline: values.deadline,
                description: values.description,
                ticketType: values.ticketType,
                statusId: values.statusId,
                projectId: values.projectId,
            }

            Actions.TicketActions.create(createReq, headerBuilder.getHeaders())
            .then((data) => {
                history.push("/tickets")
            })
        }
        else {
            const updateReq: TicketUpdateDTO = {
                title: values.title,
                deadline: values.deadline,
                description: values.description,
                statusId: values.statusId,
                type: values.ticketType
            }
            console.log(updateReq)
            headerBuilder.resetHeaders()
            .addHeader("Authorization", `Bearer ${localStorage.getItem("token")}`)

            Actions.TicketActions.update(props.ticket.id, updateReq, headerBuilder.getHeaders())
            .then((data) => {
                history.push("/tickets")
            })
        }
    }

    if(loading) {
        return <Loading/>
    }

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
                 value={values.title}
                 onChange={handleInputChange}
                 type="singleLine"
                 error={errors.name}
                />

                <CustomInput
                 name="description"
                 label="Ticket description"
                 value={values.description}
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
            item
            container
            xs={12}
            md={6}
            direction="column"
            alignItems="center"
            justify="center"
            style={{ padding: "10px"}}
            >
                {!props.ticket && <CustomSelect 
                title="Select Project"
                name="projectId"
                values={projectsSelect}
                onChange={handleInputChange}
                />}
                <CustomSelect 
                title="Select Ticket Status"
                name="statusId"
                values={statusSelect}
                value={props.ticket?.status.id}
                onChange={handleInputChange}
                />
                <CustomSelect 
                title="Select Ticket Type"
                name="ticketType"
                value={props.ticket?.type}
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