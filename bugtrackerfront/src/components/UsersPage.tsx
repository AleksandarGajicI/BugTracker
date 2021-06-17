import { Grid, TextField } from "@material-ui/core"
import Layout from "./Layout"
import UsersTable from "./UsersTable"

function UsersPage() {

    function handleInputChange(e: any) {
        if(e.key === "Enter") {
            console.log(e.target.value)
        }
    }

    return (
        <Layout>
            <Grid
            container
            >
                <Grid
                item
                xs={12}
                md={12}
                >
                    <TextField
                    id="filled-full-width"
                    label="Search for user by email"
                    style={{ margin: 8 }}
                    placeholder="Enter email"
                    fullWidth
                    margin="normal"
                    variant="filled"
                    // onChange={(e) => handleInputChange(e)}
                    onKeyDown={(e) => handleInputChange(e)}
                    />
                </Grid>
            </Grid>
            <UsersTable/>
        </Layout>
    )
}

export default UsersPage