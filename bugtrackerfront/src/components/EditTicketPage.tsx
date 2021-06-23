import { Grid } from "@material-ui/core"
import { useState } from "react"
import { useEffect } from "react"
import { useParams } from "react-router"
import { useHistory } from "react-router-dom"
import Actions from "./actions/Actions"
import { HeadersBuilder } from "./actions/HeadersBuilder"
import TicketForm from "./forms/TicketForm"
import Layout from "./Layout"
import Loading from "./Loading"
import { TicketDTO } from "./models/dtos/TIcketDTO"

function EditTicketPage() {
    const {id} = useParams<{id: string}>()
    const [ticket, setTicket] = useState<TicketDTO>()
    const [loading, setLoading] = useState(false)
    const history = useHistory()
    const headerBuilder = new HeadersBuilder()

    useEffect(() => {
        if(!localStorage.getItem("token")) {
            history.push("/")
        }
        setLoading(true)

        headerBuilder.resetHeaders()
        .addHeader("Authorization", `Bearer ${localStorage.getItem("token")}`)
        Actions.TicketActions.getById(id, headerBuilder.getHeaders())
        .then(ticket => {
            console.log("ticket", ticket)
            setTicket(ticket)
            setLoading(false)
        })
    }, [])

    if(loading) {
        return <Loading/>
    }

    return (
        <Layout>
            <Grid
            item>
                <TicketForm 
                title="Edit Ticket" 
                buttonTitle="SAVE CHANGES"
                ticket={ticket}
                />
            </Grid>
        </Layout>
    )
}

export default EditTicketPage