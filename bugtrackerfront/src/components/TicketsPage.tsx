import { Button, Grid, Typography } from "@material-ui/core"
import { useState } from "react"
import TicketForm from "./forms/TicketForm"
import Layout from "./Layout"
import TicketsTable from "./TicketsTable"

function TicketsPage() {
    const [toggle, setToggle] = useState<boolean>(false)

    return (
        <Layout>
            <Grid
            container
            >
                <Grid
                item
                container
                direction="column"
                justify="flex-start"
                style={{padding: "2em", backgroundColor: "#CCCCCD"}}
                >
                    <Typography variant="h5">Welcome to the tickets page!</Typography> 
                    <Typography style={{fontSize: "15px"}}>Here you can easilly manage your tickets</Typography> 
                </Grid>
                <Grid
                item
                container
                justify="flex-end"
                style={{marginTop: "1em"}}
                >
                    <Button
                    size="large"
                    variant="contained"
                    color="secondary"
                    onClick={() => {setToggle(!toggle)}}
                    >
                        {toggle === false
                        ? "MAKE NEW TICKET"
                        : "CANCEL"
                    }
                    </Button>
                </Grid>
                <Grid
                item
                xs={12}
                md={12}
                style={{margin: "1em", backgroundColor: "#345355"}}
                >
                    {toggle && 
                        <TicketForm 
                        title="Make New Ticket" 
                        buttonTitle="MAKE NEW TICKET"
                        />}
                </Grid>
                <Grid
                item
                container>
                    <TicketsTable withPagination={true}/>
                </Grid>
            </Grid>
        </Layout>
    )
}
export default TicketsPage