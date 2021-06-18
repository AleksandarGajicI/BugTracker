import { Grid } from "@material-ui/core"
import { useState } from "react"
import { useEffect } from "react"
import { useParams } from "react-router"
import Actions from "./actions/Actions"
import TicketForm from "./forms/TicketForm"
import Layout from "./Layout"
import { TicketDTO } from "./models/dtos/TIcketDTO"

function EditTicketPage() {
    const {id} = useParams<{id: string}>()
    const [ticket, setTicket] = useState<TicketDTO>()

    useEffect(() => {
        Actions.TicketActions.getById(id)
        .then(ticket => {
            console.log("ticket", ticket)
            setTicket(ticket)
        })
    }, [])

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