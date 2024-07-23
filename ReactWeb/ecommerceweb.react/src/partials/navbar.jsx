import './navbar.css'
const Navbar = ()=>{

    return(
<div class="container-fluid md-4 ">
    <nav class="navbar navbar-expand-md navbar-light bg-white p-0">
        <a class="navbar-brand mr-4" href="#"><strong>ECommerce</strong></a>

        <button class="navbar-toggler mr-3" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link" href="/products" id="navbarDropdown1" role="button"  aria-haspopup="true" aria-expanded="false">Products<span class="fa fa-angle-down"></span></a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#" id="navbarDropdown2" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Resources<span class="fa fa-angle-down"></span></a>
                    <div class="dropdown-menu" id="dropdown-menu2" aria-labelledby="navbarDropdown2">
                        <div class="container">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="row d-flex tab">
                                        <div class="fa-icon text-center">
                                            <span class="fa fa-folder"></span>
                                        </div>
                                        <div class="d-flex flex-column">
                                            <a class="dropdown-item" href="#">
                                                <h6 class="mb-0">WhitePaper</h6>
                                                <small class="text-muted">Marketing and report</small>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="row d-flex tab">
                                        <div class="fa-icon text-center">
                                            <span class="fa fa-question"></span>
                                        </div>
                                        <div class="d-flex flex-column">
                                            <a class="dropdown-item" href="#">
                                                <h6 class="mb-0">FAQs</h6>
                                                <small class="text-muted">Qs and answers</small>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="row d-flex tab">
                                        <div class="fa-icon text-center">
                                            <span class="fa fa-calculator"></span>
                                        </div>
                                        <div class="d-flex flex-column">
                                            <a class="dropdown-item" href="#">
                                                <h6 class="mb-0">Tools</h6>
                                                <small class="text-muted">All tools</small>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="row d-flex tab">
                                        <div class="fa-icon text-center">
                                            <span class="fa fa-paper-plane"></span>
                                        </div>
                                        <div class="d-flex flex-column">
                                            <a class="dropdown-item" href="#">
                                                <h6 class="mb-0">Success Stories</h6>
                                                <small class="text-muted">Experiences</small>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#" id="navbarDropdown3" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Customers<span class="fa fa-angle-down"></span></a>
                    <div class="dropdown-menu" id="dropdown-menu3" aria-labelledby="navbarDropdown3">
                        <div class="container">
                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="row d-flex tab">
                                        <div class="fa-icon text-center">
                                            <span class="fa fa-feed"></span>
                                        </div>
                                        <div class="d-flex flex-column">
                                            <a class="dropdown-item" href="#">
                                                <h6 class="mb-0">Feedback</h6>
                                                <small class="text-muted">Opinions, complaints</small>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="row d-flex tab">
                                        <div class="fa-icon text-center">
                                            <span class="fa fa-question"></span>
                                        </div>
                                        <div class="d-flex flex-column">
                                            <a class="dropdown-item" href="#">
                                                <h6 class="mb-0">FAQs</h6>
                                                <small class="text-muted">Qs and answers</small>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </li>
            </ul>
        </div>
    </nav>
</div>
    )
}
export default Navbar