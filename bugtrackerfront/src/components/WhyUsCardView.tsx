import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import Typography from '@material-ui/core/Typography';
import useStyles from './style/MainStyle';

interface Props {
    title: String,
    description: String,
    url: string
}

function WhyUsCardView(props: Props) {
    const classes = useStyles()

    return(
        <Card className={classes.whyUsCardView}>
            <CardMedia
            className={classes.whyUsCardViewMedia}
            image={props.url}
            title="Contemplative Reptile"
            />
            <CardContent>
            <Typography gutterBottom variant="h5" component="h2">
                {props.title}
            </Typography>
            <Typography variant="body2" color="textSecondary" component="p">
                {props.description}
            </Typography>
            </CardContent>
    </Card>
    )
}

export default WhyUsCardView