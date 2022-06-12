import Header from './Header';
import Footer from './Footer';
import { Container } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';

const Layout = (props) => {
    return (
        <div className='pt-5'>
            <Header {...props} />
            <div className='pt-3'></div>
            <Container>
                <div>
                    {props.children}
                </div>
            </Container>
        </div>
    );
}

export default Layout;