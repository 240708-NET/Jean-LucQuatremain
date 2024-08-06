

const ListItem = (props) => (
    <li onClick={() => props.handleClick(props.name)}>{props.name}</li>
)

export default ListItem;