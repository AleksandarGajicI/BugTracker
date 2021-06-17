import { useEffect, useState } from "react"
import { useParams } from "react-router"
import Actions from "./actions/Actions"
import Layout from "./Layout"
import Loading from "./Loading"
import { TicketDTO } from "./models/dtos/TIcketDTO"

function TicketPage() {
    const {id} = useParams<{id: string}>()
    const [loading, setLoading] = useState<boolean>(false)
    const [ticket, setTicket] = useState<TicketDTO>()

    useEffect(() => {
        setLoading(true)
        Actions.TicketActions.getById(id)
        .then(data => {
            console.log(data)
            setLoading(false)
            setTicket(data)
        })
    }, [])

    if(loading) {
        return (
            <Loading/>
        )
    }

    return (
        <Layout>
            {ticket?.type}
        </Layout>
    )
}

export default TicketPage