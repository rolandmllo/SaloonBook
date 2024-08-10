import React, { FC } from "react";
import IdentityService from "./../services/IdentityService";  // I assume the IdentityService is exported from this module.
import { useRouter } from 'next/router'

interface IConditionalRenderProps {
  Component: FC;
}

const ConditionalRender: FC<IConditionalRenderProps> = ({ Component }) => {
    const identityService = new IdentityService();
    const navigate = useRouter();

    const isUserAuthenticated = identityService.isUserAuthenticated();

  return isUserAuthenticated ? <Component /> : navigate.push('/Login');
};

export default ConditionalRender;